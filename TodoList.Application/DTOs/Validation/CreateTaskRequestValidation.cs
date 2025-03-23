using FluentValidation;
using TodoList.Application.DTOs.Task.Requests;

namespace TodoList.Application.DTOs.Validation;

public class CreateTaskRequestValidation : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ApplicationLayerCommonMessages.TaskValidator.TitleIsRequired)
            .NotNull().WithMessage(ApplicationLayerCommonMessages.TaskValidator.TitleIsRequired)
            .MaximumLength(100).WithMessage(ApplicationLayerCommonMessages.TaskValidator.TitleMustBeLessThan100Characters);

        RuleFor(x => x.Description)
           .NotEmpty().WithMessage(ApplicationLayerCommonMessages.TaskValidator.DescriptionIsRequired)
           .NotNull().WithMessage(ApplicationLayerCommonMessages.TaskValidator.DescriptionIsRequired)
            .MaximumLength(1000).WithMessage(ApplicationLayerCommonMessages.TaskValidator.DescriptionMustBeLessThan1000Characters);

        RuleFor(x => x.DueDate)
           .NotEmpty().NotNull().WithMessage(ApplicationLayerCommonMessages.TaskValidator.DueDateIsRequired);

        RuleFor(x => x.IsCompleted)
          .NotEmpty().NotNull().WithMessage(ApplicationLayerCommonMessages.TaskValidator.IsCompletedIsRequired);
    }
}
