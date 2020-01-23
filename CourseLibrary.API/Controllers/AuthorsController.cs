﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseLibrary.API.Helpers;
using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using CourseLibrary.API.ResourceParameters;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);                      

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);            

            if (authorFromRepo == null)
            {
                return NotFound();
            }
             
            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }
    }
}
