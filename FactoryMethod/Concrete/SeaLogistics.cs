namespace FactoryMethod
{
    class SeaLogistics : Logistics
    {
        public override ITransport CreateTansport() => new Ship();
    }
}
