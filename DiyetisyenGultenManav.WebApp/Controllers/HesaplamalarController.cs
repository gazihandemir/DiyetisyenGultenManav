using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class HesaplamalarController : Controller
    {
        // GET: Hesaplamalar
        public ActionResult HesaplaBMI()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HesaplaBMI(FormCollection frm)
        {
            string sonucStr = "";
            string sonucAciklama = "";
            string renk = "";
            double bmiKilo = Convert.ToDouble(frm["BmiKilo"].ToString());
            double bmiBoy = Convert.ToDouble(frm["BmiBoy"].ToString());

            double sonuc = bmiKilo / Math.Pow(bmiBoy / 100, 2);
            if (sonuc <= 18.5)
            {
                sonucStr = "Zayıf";
                sonucAciklama = "Zayıf sınıflandırmasına giriyorsanız kilonuz olması gereken ağırlığınızın altında demektir." +
                    " Düşük vücut ağırlığı saç dökülmesi, tırnak kırılması, halsizlik, yorgunluk ve baş ağrısı gibi şikayetlere neden olabilir." +
                    " İdeal kilograma ulaşma sürecinde önemli olan kilo artışının hızlı olması değil; sağlıklı bir kilo artışının gerçekleşmesidir." +
                    " Bu süreçte bir beslenme uzmanında yardım almanız daha sağlıklı olur. ";
                renk = "alert alert-danger";
            }
            else if (sonuc > 18.5 && sonuc <= 24.9)
            {
                sonucStr = "Normal";
                sonucAciklama = "BMI değeriniz bu aralıkta ise; kilonuz boyunuza göre ideal denilebilir. " +
                    "İdeal vücut ağırlığında olmanız hem daha dinç ve zinde olmanızı sağlar hem de hastalıklara yakalanma riskinizi düşürür";
                renk = "alert alert-success";
            }
            else if (sonuc > 24.9 && sonuc <= 29.9)
            {
                sonucStr = "Kilolu";
                sonucAciklama = "BMI değerinizin bu aralıkta olması vücut ağırlığınızın boyunuza oranla yüksek olduğunu ve obezite riski taşıdığınızı gösterir. " +
                    "İdeal kilograma inme sürecinde hızlı kilo kaybı daha sağlıksız bir vücuda temel hazırlar. " +
                    "Bu süreçte hızlı kilo kaybının yerine yavaş ve kalıcı olan ağırlık kaybının sağlıklı olduğu unutulmamalıdır. ";
                renk = "alert alert-warning";
            }
            else if (sonuc > 29.9 && sonuc <= 39.9)
            {
                sonucStr = "Şişman";
                sonucAciklama = "BMI değeriniz bu aralıkta ise obez sınıflandırmasına girmiş sayılırsınız ve vücut ağırlığınız olması gerekenin çok üstünde demektir." +
                    " Obezite diyabet, kalp-damar hastalıkları, yüksek tansiyon, kolesterol ve kanser görülme riskini artırabilir ve yaşam kalitesini olumsuz yönde etkileyebilir." +
                    " İdeal vücut ağılığına ulaşmak amacıyla hızlı kilo kaybının gerçekleşmesi kalıcı olmayan bir çözümdür ve aynı hızla ağırlık artışına neden olabilir. " +
                    "Bu süreçte ağırlık kaybının diyetisyen gözetiminde olması daha sağlıklı olur.";
                renk = "alert alert-danger";
            }
            else if (sonuc >= 40)
            {
                sonucStr = "Aşırı Şişman";
                sonucAciklama = "BMI değeriniz bu aralıkta ise morbid obez sınıfındasınızdır ve sağlığınız risk altındadır." +
                    " Yüksek vücut ağırlığı; diyabet, kalp-damar hastalıkları, yüksek tansiyon, yüksek kolesterol ve böbrek rahatsızlıkları gibi birçok sağlık sorununu beraberinde getirebilir. " +
                    "İdeal vücut ağırlığına inmeniz hem fiziksel hem de psikolojik açıdan daha sağlıklı olmanızı sağlar ve yaşam kalitenizi artırır. " +
                    "BMI değeriniz bu aralıkta ise mutlaka kan değerlerinize baktırmalısınız ve bir uzmana başvurmalısınız.";
                renk = "alert alert-danger";
            }
            ViewBag.sonuc = Math.Round(sonuc,2).ToString();
            ViewBag.sonucStr = sonucStr.ToString();
            ViewBag.sonucAciklama = sonucAciklama.ToString();
            ViewBag.renk = renk.ToString();
            return View();
            /*     double vNot = Convert.ToDouble(frm["vNot"].ToString());
             double uNot = Convert.ToDouble(frm["uNot"].ToString());
             double fNot = Convert.ToDouble(frm["fNot"].ToString());
             double ort = (vNot * 0.3) + (uNot * 0.1) + (fNot * 0.6);
             if (ort < 60)
             {
                 ViewBag.sonuc = "Kaldı";
                 ViewBag.ortalama = ort.ToString();
                 ViewBag.cl = "alert alert-danger";
             }
             else
             {
                 ViewBag.sonuc = "Geçti";
                 ViewBag.ortalama = ort.ToString();
                 ViewBag.cl = "alert alert-success";
             }*/
        }
        public ActionResult HesaplaBMH()
        {
            return View();
        }
    }
}