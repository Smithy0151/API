namespace API.DTOs
{
    public record struct AgentCreateDTO
        (string Name, 
        CommissionCreateDTO Commission, 
        List<PropertyCreateDTO> Properties,
        List<AreaCreateDTO> Areas);
}
