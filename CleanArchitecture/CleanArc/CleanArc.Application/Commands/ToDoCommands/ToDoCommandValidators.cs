﻿using FluentValidation;
using CleanArc.Application.Interfaces;
using CleanArc.Application.Models;
using CleanArc.Common.Errors;
using CleanArc.Common.Localization;
using CleanArc.Domain.Entities;
using System;
using System.Linq;
using CleanArc.Application.Common;

namespace CleanArc.Application.Commands.ToDoCommands
{
    public class AddToDoCommandValidator : AbstractValidator<AddToDoCommand>
    {
        private readonly IRepository repository;

        public AddToDoCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            RuleFor(x => x.ToDo).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(ToDo)));
            RuleFor(x => x.ToDo.Name).Must(BeOnlyOneImportant).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_IMPORTANT), nameof(ToDo.Name)));
            RuleFor(x => x.ToDo.Name).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(ToDo.Name)));
        }

        private bool BeUnique(ToDoModel toDoModel)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x=> x.Name == toDoModel.Name);
            if (toDo != null && toDo.Id != toDoModel.Id)
            {
                return false;
            }
                return true;
        }

        private bool BeOnlyOneImportant(string name)
        {
            if (!name.ToLower().Contains(ApplicationConstants.IMPORTANT_VALIDATION.ToLower()))
            {
                return true;
            }

            var todo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Name.ToLower().Contains(ApplicationConstants.IMPORTANT_VALIDATION.ToLower()));
            return todo == null;
        }

        private bool NotNullOrEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }


    public class EditToDoCommandValidator : AbstractValidator<EditToDoCommand>
    {
        private readonly IRepository repository;

        public EditToDoCommandValidator(IRepository repository,
            Ii18nService i18nService)
        {
            this.repository = repository;
            
            RuleFor(x => x.ToDo).Must(BeUnique).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.DUPLICATE_ENTITY), nameof(ToDo)));
            RuleFor(x => x.ToDo.Name).Must(NotNullOrEmpty).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.REQUIRED), nameof(ToDo.Name)));
            RuleFor(x => x.ToDo.Id).Must(Exist).WithMessage(string.Format(i18nService.GetMessage(ErrorMessagesNames.NOT_FOUND), nameof(ToDo)));
        }

        private bool BeUnique(ToDoModel toDoModel)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Name == toDoModel.Name);
            if (toDo != null && toDo.Id != toDoModel.Id)
            {
                return false;
            }
            return true;
        }

        private bool Exist(Guid? id)
        {
            var toDo = repository.GetEntities<ToDo>().FirstOrDefault(x => x.Id == id);
            if (toDo == null)
            {
                return false;
            }
            return true;
        }
        private bool NotNullOrEmpty(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}




