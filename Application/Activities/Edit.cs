using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;

namespace Application.Activities
{
    public class Edit
    {
        public class Command: IRequest
        {
            public Activity Activity{get;set;}

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity= await _context.Activities.FindAsync(request.Activity.ID);
                // activity.Title=request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Activity,activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
    
    
}
        