using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Threading;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetialsVm>
    {
        private readonly IMapper _mapper;
        private readonly INotesDbContext _dbContext;

        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteDetialsVm> Handle(GetNoteDetailsQuery reque, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == reque.Id, cancellationToken);

            if (entity == null || entity.UserId != reque.UserId)
            {
                throw new NotFoudException(nameof(Note), reque.Id);
            }

            return _mapper.Map<NoteDetialsVm>(entity);

        }
    }
}
