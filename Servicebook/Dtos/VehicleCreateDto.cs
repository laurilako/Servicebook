namespace Servicebook.Dtos
{
    public record struct VehicleCreateDto(
        string Brand,
        string Type,
        string ModelName,
        string LicensePlate,
        int Year,
        string Color
    );
}
