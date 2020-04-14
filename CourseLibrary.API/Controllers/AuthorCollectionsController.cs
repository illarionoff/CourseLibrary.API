using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authorcollections")]
    public class AuthorCollectionsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorCollectionsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                                       throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{ids}", Name = "GetAuthorsCollection")]
        public IActionResult GetAuthorCollection(
            [FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            IEnumerable<Guid> ids)
        {
            if (ids == null) return BadRequest();

            var authorsEntities = _courseLibraryRepository.GetAuthors(ids);

            if (ids.Count() != authorsEntities.Count()) return NotFound();

            var authors = _mapper.Map<IEnumerable<AuthorDto>>(authorsEntities);

            return Ok(authors);
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(
            IEnumerable<AuthorCreationDto> authorCollection)
        {
            var authorEntities = _mapper.Map<IEnumerable<Author>>(authorCollection);

            foreach (var author in authorEntities) _courseLibraryRepository.AddAuthor(author);

            _courseLibraryRepository.Save();

            var createdAuthors = _mapper.Map<IEnumerable<AuthorDto>>(authorEntities);
            var ids = string.Join(",", createdAuthors.Select(a => a.Id));

            return CreatedAtRoute("GetAuthorsCollection", new {ids}, createdAuthors);
        }
    }
}