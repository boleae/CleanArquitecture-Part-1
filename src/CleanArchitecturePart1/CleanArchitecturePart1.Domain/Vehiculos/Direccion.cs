namespace CleanArchitecture.Domain.Vehiculos;

//Object Value
//Se caracteriza porque es unico por sus valores (no pueden existir 2 direcciones iguales)
public record Direccion (
    string Pais,
    string Departamento,
    string Provincia,
    string Ciudad,
    string Calle
);