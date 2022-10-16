namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Serialization.Interfaces;

public interface IProtobufSerializer
{
    byte[] SerializeToProtobuf(object obj);
    T? DeserializeFromProtobuf<T>(byte[] byteArray);
}
