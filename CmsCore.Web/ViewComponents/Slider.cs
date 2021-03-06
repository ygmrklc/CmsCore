﻿using CmsCore.Model.Entities;
using CmsCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCore.Web.ViewComponents
{
    public class Slider:ViewComponent
    {
        private readonly ISliderService sliderService;
        
        public Slider(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            
            var slider = await GetSlider(name);
            if (slider == null)
            {
                slider = new CmsCore.Model.Entities.Slider();
            }
            if (slider.Template != null)
            {
                return View(slider.Template.ViewName, slider);
            }
            return View("Default",slider);
          
        }
        private Task<CmsCore.Model.Entities.Slider> GetSlider(string sliderName)
        {
            var sl = sliderService.GetSlider(sliderName, true);
            
           return Task.FromResult(sliderService.GetSlider(sliderName,true));
        }
    }
}
 