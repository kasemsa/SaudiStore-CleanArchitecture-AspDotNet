using SaudiStore.Application.Features.Categories.Commands.CreateCateogry;
using SaudiStore.Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudiStore.Application.Features.Categories.Queries.GetCatergoriesListWithProducts;
using SaudiStore.Application.Features.Categories.Queries.GetCategoriesListWithProducts;

namespace SaudiStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQueries());
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("allwithProducts", Name = "GetCategoriesWithProducts")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryProductListVm>>> GetCategoriesWithProducts(bool includeHistory)
        {
            GetCategoriesListWithProductsQuery getCategoriesListWithProductsQuery = new GetCategoriesListWithProductsQuery() { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getCategoriesListWithProductsQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
