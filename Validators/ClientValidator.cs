﻿using Bank.Models;
using FluentValidation;
using System;
using System.Linq;

namespace Bank.Validators
{
    /// <summary>
    /// Выполняет проверку вводимых данных о клиенте
    /// </summary>
    internal class ClientValidator:AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(vm => vm.FirstName)
                .NotEmpty().WithMessage("Имя не заполнено")
                .Must(vm => vm.All(Char.IsLetter)).WithMessage("Имя должно собержать только буквы")
                .Must(ExpansionString.StartsWithUpper).WithMessage("Имя должно начинаться с заглавной буквы");

            RuleFor(vm => vm.MiddleName)
                .NotEmpty().WithMessage("Отчество не заполнено")
                .Must(vm => vm.All(Char.IsLetter)).WithMessage("Отчество  должно собержать только буквы")
                .Must(ExpansionString.StartsWithUpper).WithMessage("Отчество должно начинаться с заглавной буквы"); ;

            RuleFor(vm => vm.SecondName)
                .NotEmpty().WithMessage("Фамилия не заполнена")
                .Must(vm => vm.All(Char.IsLetter)).WithMessage("Фамилия должно собержать только буквы")
                .Must(ExpansionString.StartsWithUpper).WithMessage("Фамилия должно начинаться с заглавной буквы"); ;

            RuleFor(vm => vm.SeriesAndPassportNumber)
                .NotEmpty().WithMessage("Паспортные данные не заполнены");

            RuleFor(t => t.Telefon)
                .Must(t=>t.StartsWith("+79")).WithMessage("Номер долже начинаться +79...")
                .Must(t => t.Substring(1).All(c => Char.IsDigit(c))).WithMessage("Номер долже содержать только цифры")
                .Length(12).WithMessage("Длина должна быть {MinLength}. Текущая длина: {TotalLength}");
        }
    }
}
