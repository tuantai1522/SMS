using MediatR;
using SMS.Core.Common;
using SMS.Core.Features.Users;

namespace SMS.UseCases.Features.Users.SignUp;

public sealed record SignUpUserCommand(
    string FirstName,
    string? MiddleName,
    string? LastName,
    string NickName,
    string Email, 
    string Password,
    DateOnly DateOfBirth, 
    GenderType GenderType,
    string Street,
    int CityId) : IRequest<Result<Guid>>;
