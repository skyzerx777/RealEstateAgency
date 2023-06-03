using Microsoft.AspNetCore.Mvc;
using RealEstateAgency.Models;
using System.IO;
using Humanizer;
using System.Globalization;
using Xceed.Words.NET;

namespace RealEstateAgency.Controllers
{
    public class GenerateContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateContract(ContractViewModel model)
        {
            // Загрузка шаблона документа
            string filePath = "wwwroot/ContractSample.docx";
            DocX document = DocX.Load(filePath);

            // Замена меток значениями
            ReplacePlaceholderWithValue(document, "{Date}", DateTime.Now.ToString("dd MMMM", new CultureInfo("uk-UA")));
            ReplacePlaceholderWithValue(document, "{YearInWords}", model.YearInWords);
            ReplacePlaceholderWithValue(document, "{SellerFullName}", model.SellerFullName);
            ReplacePlaceholderWithValue(document, "{SellerBirthday}", model.SellerBirthday);
            ReplacePlaceholderWithValue(document, "{SellerTaxNumber}", model.SellerTaxNumber);
            ReplacePlaceholderWithValue(document, "{SellerPassportNumber}", model.SellerPassportNumber);
            ReplacePlaceholderWithValue(document, "{SellerIssuedPassport}", model.SellerIssuedPassport);
            ReplacePlaceholderWithValue(document, "{SellerCityPassport}", model.SellerCityPassport);
            ReplacePlaceholderWithValue(document, "{SellerYearPassport}", model.SellerYearPassport);
            ReplacePlaceholderWithValue(document, "{SellerAdressCity}", model.SellerAdressCity);
            ReplacePlaceholderWithValue(document, "{SellerAdressStreet}", model.SellerAdressStreet);
            ReplacePlaceholderWithValue(document, "{SellerAdressHome}", model.SellerAdressHome);
            ReplacePlaceholderWithValue(document, "{SellerAddressFlat}", model.SellerAddressFlat);
            ReplacePlaceholderWithValue(document, "{BuyerFullName}", model.BuyerFullName);
            ReplacePlaceholderWithValue(document, "{BuyerBirthday}", model.BuyerBirthday);
            ReplacePlaceholderWithValue(document, "{BuyerTaxNumber}", model.BuyerTaxNumber);
            ReplacePlaceholderWithValue(document, "{BuyerPassportNumber}", model.BuyerPassportNumber);
            ReplacePlaceholderWithValue(document, "{BuyerIssuedPassport}", model.BuyerIssuedPassport);
            ReplacePlaceholderWithValue(document, "{BuyerCityPassport}", model.BuyerCityPassport);
            ReplacePlaceholderWithValue(document, "{BuyerYearPassport}", model.BuyerYearPassport);
            ReplacePlaceholderWithValue(document, "{BuyerAdressCity}", model.BuyerAdressCity);
            ReplacePlaceholderWithValue(document, "{BuyerAdressStreet}", model.BuyerAdressStreet);
            ReplacePlaceholderWithValue(document, "{BuyerAdressHome}", model.BuyerAdressHome);
            ReplacePlaceholderWithValue(document, "{BuyerAdressFlat}", model.BuyerAdressFlat);
            ReplacePlaceholderWithValue(document, "{PropertyStreet}", model.PropertyStreet);
            ReplacePlaceholderWithValue(document, "{PropertyBuilding}", model.PropertyBuilding);
            ReplacePlaceholderWithValue(document, "{PropertyFlat}", model.PropertyFlat);
            ReplacePlaceholderWithValue(document, "{PropertyLivingArea}", model.PropertyLivingArea);
            ReplacePlaceholderWithValue(document, "{PropertyGeneralArea}", model.PropertyGeneralArea);
            ReplacePlaceholderWithValue(document, "{AgentName}", model.AgentName);
            ReplacePlaceholderWithValue(document, "{Year}", DateTime.Now.Year.ToString());
            ReplacePlaceholderWithValue(document, "{NewRegistrationNumber}", model.NewRegistrationNumber);
            ReplacePlaceholderWithValue(document, "{RegistrationNumber}", model.RegistrationNumber);
            ReplacePlaceholderWithValue(document, "{OwnershipNumber}", model.OwnershipNumber);
            ReplacePlaceholderWithValue(document, "{OwnershipIssue}", model.OwnershipIssue);
            ReplacePlaceholderWithValue(document, "{OwnershipYear}", model.OwnershipYear);
            ReplacePlaceholderWithValue(document, "{OwnershipRecordNumber}", model.OwnershipRecordNumber);
            ReplacePlaceholderWithValue(document, "{Amount}", model.Amount);
            ReplacePlaceholderWithValue(document, "{OwnershipDate}", model.OwnershipDate);
            ReplacePlaceholderWithValue(document, "{OwnershipWholeAmount}", model.OwnershipWholeAmount);
            ReplacePlaceholderWithValue(document, "{OwnershipPennyAmount}", model.OwnershipPennyAmount);

            // Сохранение документа
            MemoryStream stream = new MemoryStream();
            document.SaveAs(stream);

            // Reset the position of the stream to the beginning
            stream.Position = 0;

            // Return the file as a download
            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Contract.docx");
        }

        private void ReplacePlaceholderWithValue(DocX document, string placeholder, string value)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                paragraph.ReplaceText(placeholder, value);
            }
        }
    }
}