using Microsoft.AspNetCore.Mvc;

namespace Academy_Graduation_Ceremony_Supply_Management_System.Controllers
{
    public class GraduationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectOffers(string certificateOffer,string hospitalityOffer, string giftOffer)
        {
            HttpContext.Session.SetString("CertificateOffer", certificateOffer);
            HttpContext.Session.SetString("HospitalityOffer", hospitalityOffer);
            HttpContext.Session.SetString("GiftOffer", giftOffer);


            decimal certificateUnitPrice;
            decimal hospitalityUnitPrice;
            decimal giftUnitPrice;

            switch (certificateOffer)
            {
                case "A":
                    certificateUnitPrice = 2m;
                    break;

                case "B":
                    certificateUnitPrice = 1.5m;
                    break;

                case "C":
                    certificateUnitPrice = 2.5m;
                    break;

                default:
                    return BadRequest("Select a valid certificate offer.");
            }

          
            switch (hospitalityOffer)
            {
                case "D":
                    hospitalityUnitPrice = 2m;
                    break;

                case "E":
                    hospitalityUnitPrice = 3m;
                    break;

                case "F":
                    hospitalityUnitPrice = 4m;
                    break;

                default:
                    return BadRequest("Select a valid hospitality offer.");
            }

            switch (giftOffer)
            {
                case "G":
                    giftUnitPrice = 2m;
                    break;

                case "H":
                    giftUnitPrice = 3m;
                    break;

                case "I":
                    giftUnitPrice = 4m;
                    break;

                default:
                    return BadRequest("Select a valid gift offer.");
            }
            decimal certificateTotal = 35 * certificateUnitPrice;
            decimal hospitalityTotal = 100 * hospitalityUnitPrice;
            decimal giftTotal = 35 * giftUnitPrice;

            decimal totalPrice = certificateTotal + hospitalityTotal + giftTotal;

            decimal discountPercentage;

            if (totalPrice > 500)
            {
                discountPercentage = 0.15m;
            }
            else if (totalPrice > 300)
            {
                discountPercentage = 0.10m;
            }
            else
            {
                discountPercentage = 0m;
            }

            decimal discountAmount = totalPrice * discountPercentage;
            decimal finalTotal = totalPrice - discountAmount;

            ViewBag.CertificateTotal = certificateTotal;
            ViewBag.HospitalityTotal = hospitalityTotal;
            ViewBag.GiftTotal = giftTotal;

            ViewBag.TotalPrice = totalPrice;
            ViewBag.DiscountPercentage = discountPercentage * 100;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.FinalTotal = finalTotal;

            return View();
        }
       
            [HttpGet]
            public IActionResult Review()
            {
                string? certificateOffer =
                    HttpContext.Session.GetString("CertificateOffer");

                string? hospitalityOffer =
                    HttpContext.Session.GetString("HospitalityOffer");

                string? giftOffer =
                    HttpContext.Session.GetString("GiftOffer");

                if (string.IsNullOrEmpty(certificateOffer) ||
                    string.IsNullOrEmpty(hospitalityOffer) ||
                    string.IsNullOrEmpty(giftOffer))
                {
                    return RedirectToAction("Categories");
                }

                decimal certificatePrice;
                decimal hospitalityPrice;
                decimal giftPrice;

                switch (certificateOffer)
                {
                    case "A":
                        ViewBag.CertificateSupplier = "Supplier A";
                        ViewBag.CertificateName = "Premium Certificate Package";
                        certificatePrice = 2m;
                        break;

                    case "B":
                        ViewBag.CertificateSupplier = "Supplier B";
                        ViewBag.CertificateName = "Standard Certificate Package";
                        certificatePrice = 1.5m;
                        break;

                    case "C":
                        ViewBag.CertificateSupplier = "Supplier C";
                        ViewBag.CertificateName = "Luxury Certificate Package";
                        certificatePrice = 2.5m;
                        break;

                    default:
                        return RedirectToAction("Categories");
                }

                switch (hospitalityOffer)
                {
                    case "D":
                        ViewBag.HospitalitySupplier = "Supplier D";
                        ViewBag.HospitalityName = "Coffee & Drinks Package";
                        hospitalityPrice = 2m;
                        break;

                    case "E":
                        ViewBag.HospitalitySupplier = "Supplier E";
                        ViewBag.HospitalityName = "Sandwiches & Snacks Package";
                        hospitalityPrice = 3m;
                        break;

                    case "F":
                        ViewBag.HospitalitySupplier = "Supplier F";
                        ViewBag.HospitalityName = "Full Hospitality Package";
                        hospitalityPrice = 4m;
                        break;

                    default:
                        return RedirectToAction("Categories");
                }

                switch (giftOffer)
                {
                    case "G":
                        ViewBag.GiftSupplier = "Supplier G";
                        ViewBag.GiftName = "Customized Mugs Package";
                        giftPrice = 2m;
                        break;

                    case "H":
                        ViewBag.GiftSupplier = "Supplier H";
                        ViewBag.GiftName = "Graduation Bags Package";
                        giftPrice = 3m;
                        break;

                    case "I":
                        ViewBag.GiftSupplier = "Supplier I";
                        ViewBag.GiftName = "Premium Gift Boxes Package";
                        giftPrice = 4m;
                        break;

                    default:
                        return RedirectToAction("Categories");
                }

                int certificateQuantity = 35;
                int hospitalityQuantity = 100;
                int giftQuantity = 35;

                decimal certificateTotal = certificateQuantity * certificatePrice;
                decimal hospitalityTotal = hospitalityQuantity * hospitalityPrice;
                decimal giftTotal = giftQuantity * giftPrice;

                decimal totalPrice =
                    certificateTotal + hospitalityTotal + giftTotal;

                decimal discountPercentage;

                if (totalPrice > 500)
                {
                    discountPercentage = 0.15m;
                }
                else if (totalPrice > 300)
                {
                    discountPercentage = 0.10m;
                }
                else
                {
                    discountPercentage = 0m;
                }

                decimal discountAmount = totalPrice * discountPercentage;
                decimal finalTotal = totalPrice - discountAmount;

                ViewBag.CertificateQuantity = certificateQuantity;
                ViewBag.CertificatePrice = certificatePrice;
                ViewBag.CertificateTotal = certificateTotal;

                ViewBag.HospitalityQuantity = hospitalityQuantity;
                ViewBag.HospitalityPrice = hospitalityPrice;
                ViewBag.HospitalityTotal = hospitalityTotal;

                ViewBag.GiftQuantity = giftQuantity;
                ViewBag.GiftPrice = giftPrice;
                ViewBag.GiftTotal = giftTotal;

                ViewBag.TotalPrice = totalPrice;
                ViewBag.DiscountPercentage = discountPercentage * 100;
                ViewBag.DiscountAmount = discountAmount;
                ViewBag.FinalTotal = finalTotal;

                return View();
            }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }


    }
}
