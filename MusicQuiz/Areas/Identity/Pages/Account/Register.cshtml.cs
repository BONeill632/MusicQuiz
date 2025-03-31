using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MusicQuiz.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UserData> _signInManager;
        private readonly UserManager<UserData> _userManager;
        private readonly IUserStore<UserData> _userStore;
        private readonly IUserEmailStore<UserData> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="userStore"></param>
        /// <param name="signInManager"></param>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public RegisterModel(
            UserManager<UserData> userManager,
            IUserStore<UserData> userStore,
            SignInManager<UserData> signInManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Input model
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel
        {
            FirstName = string.Empty,
            LastName = string.Empty,
            StudentID = string.Empty,
            Email = string.Empty,
            Password = string.Empty,
            ConfirmPassword = string.Empty,
            AcademicYear = string.Empty
        };

        /// <summary>
        /// Return URL
        /// </summary>
        public string ReturnUrl { get; set; } = string.Empty;

        /// <summary>
        /// External logins
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; } = [];

        /// <summary>
        /// Academic year options
        /// </summary>
        public List<string> AcademicYearOptions { get; set; } = [];

        /// <summary>
        /// Input model
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Forename
            /// </summary>
            [Required]
            [Display(Name = "Forename")]
            public required string FirstName { get; set; }

            /// <summary>
            /// Surname
            /// </summary>
            [Required]
            [Display(Name = "Surname")]
            public required string LastName { get; set; }

            /// <summary>
            /// Student ID
            /// </summary>
            [Required]
            [Display(Name = "Student ID")]
            public required string StudentID { get; set; }

            /// <summary>
            /// Academic year
            /// </summary>
            [Required]
            [Display(Name = "Academic year")]
            public string? AcademicYear { get; set; }

            /// <summary>
            /// Email
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public required string Email { get; set; }

            /// <summary>
            /// Password
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public required string Password { get; set; }

            /// <summary>
            /// Confirm password
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public required string ConfirmPassword { get; set; }
        }

        /// <summary>
        /// Getting list of academic years, this year, the previous year and next
        /// This is more of a just-in-case rather than necesscary
        /// The users of the app will tpically be for the modue in that year.
        /// They will need to change this in the user section if they use this application
        /// for more than an academic year as this will be used for leaderboards and assessments
        /// </summary>
        /// <returns></returns>
        public List<string> GetAcademicYearOptions()
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            // Adjust the logic to consider the current academic year as 24/25 for Sept - Aug
            var currentAcademicYear = (currentMonth >= 9 && currentMonth <= 12) 
                ? currentYear
                : (currentMonth >= 1 && currentMonth <= 8) ? currentYear - 1 : currentYear;

            // Generate the correct academic year options
            var options = new List<string>
            {
                // Previous academic year
                $"{(currentAcademicYear - 1) % 100}/{currentAcademicYear % 100}",

                // Current academic year
                $"{currentAcademicYear % 100}/{(currentAcademicYear + 1) % 100}",

                // Next academic year
                $"{(currentAcademicYear + 1) % 100}/{(currentAcademicYear + 2) % 100}"
            };

            return options;
        }

        /// <summary>
        /// On get async
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = [.. (await _signInManager.GetExternalAuthenticationSchemesAsync())];

            // Populate the Academic Year options
            AcademicYearOptions = GetAcademicYearOptions();
        }

        /// <summary>
        /// On post async
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = [.. (await _signInManager.GetExternalAuthenticationSchemesAsync())];

            // Repopulate the AcademicYearOptions in case of errors
            AcademicYearOptions = GetAcademicYearOptions();

            if (ModelState.IsValid)
            {
                // Check if the email is already in use
                var existingUser = await _userManager.FindByEmailAsync(Input.Email);
                if (existingUser != null)
                {
                    // Email is already in use, add a custom error message
                    ModelState.AddModelError(string.Empty,
                        "This email is already taken. If it's your account, please use the 'Forgot your password?' link.");
                    return Page();
                }

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                // Set the Forename, Surname, StudentID, and AcademicYear
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.StudentID = Input.StudentID;
                user.AcademicYear = Input.AcademicYear ?? "Unknown";

                // Increment the UserID
                var lastUserID = await _context.LastAssignedUserID.FirstOrDefaultAsync();
                if (lastUserID == null)
                {
                    ModelState.AddModelError(string.Empty, "Failed to retrieve the last assigned user ID.");
                    return Page();
                }

                // Set the new UserID and update the LastAssignedUserID
                user.IntID = lastUserID.LastUserID + 1;
                lastUserID.LastUserID = user.IntID;

                //Used to bypass email verification for password reset.
                //Proving tricky to implement verification
                user.EmailConfirmed = true;

                // Save the updated student ID
                _context.LastAssignedUserID.Update(lastUserID);
                await _context.SaveChangesAsync();

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Assign the "User" role to the new user
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return Page();
                    }

                    // Set LastLoggedIn field to DateTime.Now
                    user.LastLoggedIn = DateTime.Now;

                    // Update the user in the database
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got here, something failed. Repopulate the AcademicYearOptions again just in case.
            AcademicYearOptions = GetAcademicYearOptions();

            return Page();
        }

        /// <summary>
        /// Create a new instance of UserData
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private UserData CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserData>() ?? throw new InvalidOperationException($"Can't create an instance of '{nameof(UserData)}'.");
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UserData)}'. Ensure that '{nameof(UserData)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        /// <summary>
        /// Get the email store
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private IUserEmailStore<UserData> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return _userStore as IUserEmailStore<UserData> ?? throw new InvalidOperationException("User store does not support email.");
        }
    }
}
