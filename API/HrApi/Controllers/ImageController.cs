using AutoMapper;
using HrApi.BussinessLogic.Services.Interfaces;
using HrApi.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using HrApi.DTO;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public ImageController(IImageService imageService, IMapper mapper)
        {

            _imageService = imageService;
            _mapper = mapper;
            
        }
        [HttpPost]
        public async Task<ActionResult> UploadImage()
        {

            foreach (var file in Request.Form.Files)
            {
                Image img = new Image();

                img.ImageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
                try
                {
                    await _imageService.AddImage(img);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetImage(int id)
        {
            var img = await _imageService.GetImage(id);
            if (img == null)
            {
                return NotFound();
            }
            var imgDTO = new
            {
                ImageData = Convert.ToBase64String(img.ImageData),
                ImageTitle=img.ImageTitle,
                Id=img.Id
             };
            return Ok(imgDTO);
        }
    }
    }

