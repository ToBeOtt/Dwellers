using DwellerApplication.Application.Services.Registration;
using DwellerApplication.Core.Helpers;
using DwellerApplication.Core.Models;
using DwellerApplication.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace DwellerApplication.Areas.Identity.Pages.Account
{
    public class RegisterHouseOwnerModel : PageModel
    {
        private readonly RegistrationServices _registrationServices;
        private readonly ILogger<RegisterHouseOwnerModel> _logger;

        public RegisterHouseOwnerModel(RegistrationServices registrationServices, ILogger<RegisterHouseOwnerModel> logger)
        {
            _registrationServices = registrationServices;
            _logger = logger;
        }

        [BindProperty]
        public HouseRegistrationModel RegModel { get; set; }

        public class HouseRegistrationModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "{0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 3)]
            [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "{0} får bara innehålla bokstäver eller siffror.")]
            [Display(Name = "Husnamnet")]
            public string HouseName { get; set; }

            [Required]
            [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "{0} får bara innehålla bokstäver eller siffror.")]
            [Display(Name = "Husbeskrivningen")]
            public string HouseDesc { get; set; }
        }


        [BindProperty]
        public string UserName { get; set; }
        public async Task<IActionResult> OnGetAsync(string email)
        {
            UserName = email;
            return Page();
        }



        [BindProperty]
        public bool RegistrationComplete { get; set; }
        public async Task<IActionResult> OnPostAsync(string userName)
        {
            if (ModelState.IsValid)
            {
                var result = await _registrationServices.AssembleHouseWithUser
                    (RegModel.HouseName, RegModel.HouseDesc, userName);
                
                if (result.Outcome == OperationOutcome.Success)
                {
                    RegistrationComplete = true;
                    return Page();
                }
                else
                {
                    var errorMessage = result.ErrorMessage;
                    return Page();
                }            
            }

            return Page();
        }

    }
}
