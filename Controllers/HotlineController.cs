using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ssc.consulting.switchboard.Infactractures;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Services;
using ssc.consulting.switchboard.ViewModels;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("Admin")]
    public class HotlineController : Controller
    {
        private readonly IHotlineService _iService = new HotlineService();
        readonly int _rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());
        //
        // GET: /Hotline/
        [Route("Hotline"), Route("Hotline/Index")]
        public ActionResult Index(int page = 1)
        {
            var data = new HotlineViewModel
            {
                ListShow = _iService.GetList(page, _rowsdisplay),
                TotalRecord = _iService.TotalRecord()
            };
            return View(data);
        }

        [Route("Hotline/Credit"), Route("Hotline/Credit/{id}")]
        public ActionResult Credit(Guid? id)
        {
            if (id.IsNull())
                return View(new HotLine { Position = _iService.GetPosition() });
            var result = _iService.GetEntityById(id.GetValueOrDefault());
            return View(result);
        }

        [Route("Hotline/Credit"), Route("Hotline/Credit/{id}")]
        [HttpPost]
        public ActionResult Credit(HotLine model, HttpPostedFileBase ImageUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var resultImage = UploadFileResult.UploadImage(ImageUrl);

            if (resultImage.IsSuccess == false && resultImage.Result != "")
            {
                SessionUserHelper.CreateSessionError(resultImage.Result);
                return View(model);
            }
            model.ImageUrl = resultImage.FileName;

            if (model.Id.IsGuidEmpty())
            {
                if (_iService.IsExitsPosition(model.Position))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.PositionExist + _iService.GetPosition());
                    return View(model);
                }
                if (_iService.Add(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.AddSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.AddNonSuccess);
                }
            }
            else
            {
                var old = _iService.GetEntityById(model.Id);
                if (old.Position != model.Position && _iService.IsExitsPosition(model.Position))
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.PositionExist + _iService.GetPosition());
                    return View(model);
                }

                if (resultImage.FileName == "")
                {
                    model.ImageUrl = old.ImageUrl;
                }

                if (_iService.Update(model))
                {
                    SessionUserHelper.CreateSessionSuccess(ConstantStrings.EditSuccess);
                }
                else
                {
                    SessionUserHelper.CreateSessionError(ConstantStrings.EditNonSuccess);
                }
            }


            return RedirectToAction("Index");
        }

        [Route("Hotline/Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            if (_iService.Delete(id))
            {
                SessionUserHelper.CreateSessionSuccess(ConstantStrings.DeleteSuccess);
            }
            else
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.DeleteNonSuccess);
            }
            return RedirectToAction("Index");
        }

        [Route("Hotline/Active/{id}")]
        public ActionResult Active(Guid id)
        {
            if (_iService.Active(id))
            {
                SessionUserHelper.CreateSessionSuccess(ConstantStrings.UpdateStatusSuccess);
            }
            else
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.UpdateStatusNonSuccess);
            }
            return RedirectToAction("Index");
        }

        [Route("Hotline/Disable/{id}")]
        public ActionResult Disable(Guid id)
        {
            if (_iService.Disable(id))
            {
                SessionUserHelper.CreateSessionSuccess(ConstantStrings.UpdateStatusSuccess);
            }
            else
            {
                SessionUserHelper.CreateSessionError(ConstantStrings.UpdateStatusNonSuccess);
            }
            return RedirectToAction("Index");
        }
	}
}