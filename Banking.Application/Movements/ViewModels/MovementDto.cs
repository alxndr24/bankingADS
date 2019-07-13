namespace Banking.Application.Movements.ViewModels
{
    public class MovementDto
    {
        public string fecha_ope { get; set; }
        public string monto { get; set; }
        public string tipo_movimiento { get; set; }

        public MovementDto()
        {
        }
    }
}
