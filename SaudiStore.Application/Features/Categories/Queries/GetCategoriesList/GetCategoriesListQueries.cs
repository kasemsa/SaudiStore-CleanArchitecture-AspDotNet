﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueries:IRequest<List<CategoryListVm>>
    {

    }
}
