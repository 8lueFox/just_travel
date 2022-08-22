using JT.Application.Common.Interfaces;

namespace JT.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
