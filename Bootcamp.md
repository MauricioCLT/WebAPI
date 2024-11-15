2 - Crear un nuevo DTO para el request crear y actualizar.
3 - Por cada validación que usen, setearle un mensaje idóneo de acuerdo a la validación.
4 - Crear una nueva clase DTO para el request actualizar y crear.

## Siempre que queramos hacer cambios en la estructura de la DB
1. Aplicar cambios a las entitdades / crearlas
2. Agregar los dbset<> correspondientes en el Context.
3. Configurar estas entidades nuevas.
4. Aplicar estas configuraciones.
5. Crear las migraciones.

```sh
dotnet ef migrations add PaymentChargeEntities -p .\Infraestructura\ -s .\WebAPI\
```

7. Verificar la migración.
8. Actualizar la base de datos.

```sh
dotnet ef database update -p .\Infraestructura\ -s .\WebAPI\
```

8. Agregar la interfaz y el repositorio a la inyección de dependencias.
# Tarea
- crear un Endpoint, con las siguiente caracteristicas 
1. /Account/1 Que obtenga los detalles de la cuenta y llene las propiedades del objeto modelo.

- [ ] AccountRepository.cs

Crear un nuevo mapping para account

```sql
(SELECT "CardId" from public."Cards" Order By random() limit 1)
```

- [x] Implementa el Mapping de Card
- [x] Crear la Interfaz de la Entidad Card
- [x] Crear el Repository de Card
- [x] Implementar las validaciones

Hacer funcionar /Customers/{id}/Cards

Error en la base de datos
```cs

```


1. Implementar el servicio de Card.
2. En el método que sirve para pagar la deuda de la tarjeta manejarlo como una transacción, (es decir se guarda recién al final)


---
- [ ] Terminar el Payment desde el Card

Response: 
```json
{
  "paymentId": "54321",
  "cardId": "98765",
  "amount": 200,
  "availableCredit": 8050,
  "date": "2024-11-11"
}
```


---
  
# Ejercicio: Gestión de Entidades Operativas del Cliente

## Descripción del Problema

Diseña un sistema que permita guardar información sobre las entidades con las que opera un cliente y los productos que tiene asociados a cada entidad. Cada cliente puede interactuar con múltiples entidades `Muchos Clientes a Muchas Entidades`, y cada entidad puede ofrecer diferentes productos al cliente.

### Requerimientos Funcionales

- [x] 1. **Guardar entidades y productos del cliente:**
   - Diseñar un endpoint que permita registrar las entidades financieras o comerciales con las que opera un cliente.
   - Cada entidad debe estar asociada a una lista de productos específicos.

- [ ] 2. **Consultar entidades y productos:**
   - Diseñar un endpoint que permita consultar todas las entidades y productos asociados a un cliente.

### Ejemplo de Escenario

Un cliente opera con las siguientes entidades:
- **Banco Sudameris**:
  - Producto: Tarjeta de Crédito
  - Producto: Préstamo Activo
- **Claro**:
	  - Producto: Plan de Telefonía

El sistema debe permitir almacenar esta información y, posteriormente, consultarla.

### Consideraciones Técnicas

1. Los estudiantes deben definir:
   - El formato de los datos a almacenar (estructura de las entidades, productos y su relación con el cliente).
   - Los detalles de los requests y responses de los endpoints.

2. **Endpoints sugeridos**:
   - `POST /api/customers/{customerId}/entities`  
     Para registrar una entidad y sus productos asociados a un cliente.
   - `GET /api/customers/{customerId}/entities`  
     Para consultar las entidades y productos asociados a un cliente.

3. El diseño debe ser flexible para admitir:
   - Múltiples entidades por cliente.
   - Múltiples productos por entidad.
   - Actualización y eliminación de productos o entidades según sea necesario.

4. Se debe considerar cómo manejar la relación entre cliente, entidades y productos de manera eficiente.

### Objetivo del Ejercicio

- Que los estudiantes diseñen las estructuras de datos necesarias.
- Que definan los cuerpos de las solicitudes y respuestas en base a los requisitos.
- Que implementen un modelo de relación entre cliente, entidades y productos.