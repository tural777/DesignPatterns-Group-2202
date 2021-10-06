namespace FactoryMethod
{
    class RoadLogistics : Logistics
    {
        public override ITransport CreateTansport() => new Truck();
    }
}
