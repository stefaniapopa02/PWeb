using System.Net;

namespace MobyLabWebProgramming.Core.Errors;

/// <summary>
/// Common error messages that may be reused in various places in the code.
/// </summary>
public static class CommonErrors
{
    public static ErrorMessage UserNotFound => new(HttpStatusCode.NotFound, "User doesn't exist!", ErrorCodes.EntityNotFound);
    public static ErrorMessage FileNotFound => new(HttpStatusCode.NotFound, "File not found on disk!", ErrorCodes.PhysicalFileNotFound);
    public static ErrorMessage TechnicalSupport => new(HttpStatusCode.InternalServerError, "An unknown error occurred, contact the technical support!", ErrorCodes.TechnicalError);

    public static ErrorMessage BreedNotFound => new(HttpStatusCode.NotFound, "Breed doesn't exist!", ErrorCodes.EntityNotFound);

    public static ErrorMessage ShelterNotFound => new(HttpStatusCode.NotFound, "Shelter doesn't exist!", ErrorCodes.EntityNotFound);

    public static ErrorMessage AnimalNotFound => new(HttpStatusCode.NotFound, "Animal doesn't exist!", ErrorCodes.EntityNotFound);

    public static ErrorMessage AdoptionHistoryNotFound => new(HttpStatusCode.NotFound, "AdoptionHistory doesn't exist!", ErrorCodes.EntityNotFound);

    public static ErrorMessage ProfileNotFound => new(HttpStatusCode.NotFound, "Profile doesn't exist!", ErrorCodes.EntityNotFound);
}
