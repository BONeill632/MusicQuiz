using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using System.ComponentModel.DataAnnotations;
using System;
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
        private readonly ApplicationDbContext _context; // Inject your DB context

        public RegisterModel(
            UserManager<UserData> userManager,
            IUserStore<UserData> userStore,
            SignInManager<UserData> signInManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext context) // Inject your DB context
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _context = context; // Initialize the context
        }

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

        public string ReturnUrl { get; set; } = string.Empty;

        public IList<AuthenticationScheme> ExternalLogins { get; set; } = [];

        public List<string> AcademicYearOptions { get; set; } = [];

        public class InputModel
        {
            [Required]
            [Display(Name = "Forename")]
            public required string FirstName { get; set; }

            [Required]
            [Display(Name = "Surname")]
            public required string LastName { get; set; }

            [Required]
            [Display(Name = "Student ID")]
            public required string StudentID { get; set; }

            [Required]
            [Display(Name = "Academic year")]
            public required string AcademicYear { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public required string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public required string Password { get; set; }

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



        public async Task OnGetAsync(string returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // Populate the Academic Year options
            AcademicYearOptions = GetAcademicYearOptions();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                // Set the Forename, Surname, StudentID, and AcademicYear
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.StudentID = Input.StudentID;
                user.AcademicYear = Input.AcademicYear;

                // Increment the UserID
                var lastUserID = await _context.LastAssignedUserID.FirstOrDefaultAsync();

                // Set the new UserID and update the LastAssignedUserID
                user.IntID = lastUserID.LastUserID + 1;

                // Save the updated student ID
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

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private UserData CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserData>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UserData)}'. " +
                    $"Ensure that '{nameof(UserData)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        private IUserEmailStore<UserData> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<UserData>)_userStore;
        }
    }
}
