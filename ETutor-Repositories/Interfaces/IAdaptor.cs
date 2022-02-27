namespace ETutor_Repositories.Interfaces
{

    public interface IAdaptor<InputType, OutputType>
    {
        OutputType Adapt(InputType input); //Generic for adapter
    }

}