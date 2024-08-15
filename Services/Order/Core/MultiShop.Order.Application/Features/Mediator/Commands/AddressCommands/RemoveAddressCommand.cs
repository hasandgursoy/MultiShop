﻿using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands
{
    public class RemoveAddressCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAddressCommand(int id)
        {
            Id = id;
        }
    }
}
