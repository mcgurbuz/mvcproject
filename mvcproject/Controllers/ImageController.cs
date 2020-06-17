using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproject.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase Upl)
        {
            string uzanti, path;
            try
            {
                Guid g = Guid.NewGuid();
                uzanti = Path.GetExtension(Upl.FileName);
                path = Server.MapPath(String.Concat(@"/Uploads/", g.ToString(), uzanti));
                mdlUploadImages mdl = new mdlUploadImages();
                Upload up = new Upload();
                up.GuidID = g;
                up.Ext = uzanti;
                up.Date = DateTime.Now;
                mdl.Uploads.Add(up);
                mdl.SaveChanges();
                using (Image img = Image.FromStream(Upl.InputStream))
                {
                    img.Save(Path.Combine(path), ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public ActionResult Listele()
        {
            try
            {
                List<ResimList> res = new List<ResimList>();
                mdlUploadImages mdl = new mdlUploadImages();
                List<Upload> uplList = mdl.Uploads.OrderByDescending(x => x.Date).ToList();
                foreach (Upload item in uplList)
                {
                    ResimList rs = new ResimList();
                    rs.Path = "/Uploads/" + item.GuidID.ToString() + item.Ext;
                    rs.Tarih = item.Date.ToString("dd.MM.yyyy HH:mm:ss");
                    res.Add(rs);
                }
                return View(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}