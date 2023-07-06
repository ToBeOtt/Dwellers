using DwellerApplication.Application.Services.Registration;
using DwellerApplication.Application.Services.RoleServices;
using DwellerApplication.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace DwellerApplication.Areas.Identity.Pages.Account
{
    public class RegisterHouseMemberModel : PageModel
    {
        private readonly ILogger<RegisterHouseMemberModel> _logger;
        private readonly RoleService _roleService;
        private readonly RegistrationServices _registrationServices;

        public RegisterHouseMemberModel(ILogger<RegisterHouseMemberModel> logger, RoleService roleService,
            RegistrationServices registrationServices)
        {
            _logger = logger;
            _roleService = roleService;
            _registrationServices = registrationServices;
        }

        [BindProperty]
        [Required]
        [StringLength(15, ErrorMessage = "{0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "{0} får bara innehålla bokstäver eller siffror.")]
        [Display(Name = "Inbjudningskoden")]
        public string InvitationCode { get; set; }

        [BindProperty]
        public string Username { get; set; }


        public async Task<IActionResult> OnGetAsync(string email)
        {
            Username = email;
            return Page();
        }

        [BindProperty]
        public bool RegistrationComplete { get; set; }
        public async Task<IActionResult> OnPostAsync(string username)
        {
            if (ModelState.IsValid)
            {
                if (! await _registrationServices.AttachUserToHouse(InvitationCode, username))
                {
                    throw new ArgumentException();
                }
            }
            RegistrationComplete = true;
            return Page();
        }

    }
}
