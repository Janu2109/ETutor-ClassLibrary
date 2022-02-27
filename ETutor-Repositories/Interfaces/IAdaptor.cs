namespace VehicleLibrary
{

    public interface IAdaptor<InputType, OutputType>
    {
        OutputType Adapt(InputType input); //Generic for adapter
    }

}