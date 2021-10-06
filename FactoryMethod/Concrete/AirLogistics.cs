namespace FactoryMethod
{
    class AirLogistics : Logistics
    {
        public override ITransport CreateTansport() => new Airplane();
    }
}
