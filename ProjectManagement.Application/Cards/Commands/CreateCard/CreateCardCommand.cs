using MediatR;
using ProjectManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Application.Cards.Commands.CreateCard
{
    public class CreateCardCommand : IRequest<string>
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string CreatedBy { get; set; }
    }
}
