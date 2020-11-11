using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingBlazor.Models;

namespace TestingBlazor.Validators
{
    public class PersonValidatorComponent : ComponentBase
    {
        private ValidationMessageStore messageStore;

        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(PersonValidatorComponent)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(PersonValidatorComponent)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            messageStore = new ValidationMessageStore(CurrentEditContext);

            CurrentEditContext.OnFieldChanged += (s, e) =>
                OnFieldChanged(s, e);

        }

        public void OnFieldChanged(object s, FieldChangedEventArgs e)
        {
            messageStore.Clear(e.FieldIdentifier);
            CurrentEditContext.NotifyValidationStateChanged();
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var err in errors)
            {
                messageStore.Add(CurrentEditContext.Field(err.Key), err.Value);
            }

            CurrentEditContext.NotifyValidationStateChanged();
        }

        public void ClearErrors()
        {
            messageStore.Clear();
            CurrentEditContext.NotifyValidationStateChanged();
        }

        public bool Validate(Person p)
        {
            var validator = new PersonValidator();
            var result = validator.Validate(p);

            var errors = result.Errors.GroupBy(item => item.PropertyName).ToDictionary(g => g.Key, g => g.Select(item => item.ErrorMessage).ToList());

            ClearErrors();
            if (errors.Count > 0)
            {
                DisplayErrors(errors);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
