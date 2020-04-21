using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanOfLettersAPI.Context;
using OceanOfLettersAPI.Models;
using OceanOfLettersAPI.Utilities;

namespace OceanOfLettersAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        public static IWebHostEnvironment Environment;

        public ImagesController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        [Route("covers")]
        [HttpPost]
        public async Task<ActionResult<Response>> Covers([FromServices] OceanOfLettersContext _context, [FromForm]FilesUp filesUp, [FromQuery]string path, [FromQuery]string name)
        {

            Response response = new Response();
            Cover cover = new Cover();

            try
            {
                if (filesUp.File.Length > 0)
                {

                    if (!Directory.Exists(Environment.WebRootPath + "\\Covers\\"))
                    {
                        Directory.CreateDirectory(Environment.WebRootPath + "\\Covers\\");
                    }

                    using FileStream fileStream = System.IO.File.Create(Environment.WebRootPath + "\\Covers\\" + path);
                    await filesUp.File.CopyToAsync(fileStream);
                    fileStream.Flush();
                    cover.Url = "http://localhost:5000/Covers/" + path;
                    cover.Path = path;
                    cover.Name = name;
                    response.Cover = cover;

                    _context.Add(cover);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    response.Message = "Arquivo vázio!";
                    response.BadRequest = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return Ok(response);


        }

        [Route("avatars")]
        [HttpPost]
        public async Task<ActionResult<Response>> Avatars([FromServices] OceanOfLettersContext _context, [FromForm]FilesUp filesUp, [FromQuery]string path, [FromQuery]string name)
        {

            Response response = new Response();
            Avatar avatar = new Avatar();

            try
            {
                if (filesUp.File.Length > 0)
                {

                    if (!Directory.Exists(Environment.WebRootPath + "\\Avatars\\"))
                    {
                        Directory.CreateDirectory(Environment.WebRootPath + "\\Avatars\\");
                    }

                    using FileStream fileStream = System.IO.File.Create(Environment.WebRootPath + "\\Avatars\\" + path);
                    await filesUp.File.CopyToAsync(fileStream);
                    fileStream.Flush();
                    avatar.Url = "http://localhost:5000/Avatars/" + path;
                    avatar.Path = path;
                    avatar.Name = name;
                    response.Avatar = avatar;

                    _context.Add(avatar);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    response.Message = "Arquivo vázio!";
                    response.BadRequest = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.BadRequest = true;
            }

            if (response.BadRequest)
                return BadRequest(response);
            else
                return Ok(response);


        }

    }

}