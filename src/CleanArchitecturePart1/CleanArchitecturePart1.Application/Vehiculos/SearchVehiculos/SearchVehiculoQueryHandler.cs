using ClearArchitecture.Application.Abstractions.Data;
using ClearArchitecture.Application.Abstractions.Messaging;
using ClearArchitecture.Domain.Abstractions;
using ClearArchitecture.Domain.Alquileres;
using Dapper;

namespace ClearArchitecture.Application.Vehiculos.SearchVehiculos;

internal sealed class SearchVehiculosQueryHandler
    : IQueryHandler<SearchVehiculosQuery, IReadOnlyList<VehiculoResponse>>
{
    private static readonly int[] ActiveAlquilerStatuses = 
    {
        (int)AlquilerStatus.Reservado,
        (int)AlquilerStatus.Confirmado,
        (int)AlquilerStatus.Completado
    };
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchVehiculosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(SearchVehiculosQuery request, CancellationToken cancellationToken)
    {
        if(request.FechaInicio > request.FechaFin)
            return new List<VehiculoResponse>();
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT 
                a.id AS Id,
                a.modelo AS Modelo,
                a.precio_monto AS Precio,
                a.precio_tipo_moneda as TipoMoneda,
                a.direccion_pais as Pais,
                a.direccion_departamento as Departamento,
                a.direccion_provincia as Provincia,
                a.direccion_ciudad as Ciudad,
                a.calle AS Calle

            FROM vehiculos AS a
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM alquileres AS b
                WHERE
                    b.vehiculo_id = a.vehiculo_id AND
                    b.duracion_inicio <= @EndDate AND
                    b.duracion_final >= @StartDate AND
                    b.status = ANY(@ActiveAlquilerStatuses)
            )

        """;
    
        var vehiculos = await connection.QueryAsync<VehiculoResponse, DireccionResponse, VehiculoResponse>
                        (sql,
                        (vehiculo, direccion) => {
                            vehiculo!.Direccion = direccion;
                            return vehiculo;

                        },  
                        new {
                            StartDate = request.FechaInicio,
                            EndDate = request.FechaFin,
                            ActiveAlquilerStatuses
                        },
                        splitOn: "Pais"
                        );
        return vehiculos.ToList();
    }
}
