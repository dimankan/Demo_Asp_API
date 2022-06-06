using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNote.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid Id { get; internal set; }
        public Guid UserId { get; internal set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}