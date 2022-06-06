using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Notes.Application.Interfaces;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetNoteListQueryHandler(INotesDbContext dbcontext, IMapper mapper) => (_dbcontext, _mapper) = (dbcontext, mapper);
        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var noteQuery = await _dbcontext.Notes.Where(note => note.UserId == request.UeserId).ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new NoteListVm { Notes = noteQuery };
        }
        
    }
}
