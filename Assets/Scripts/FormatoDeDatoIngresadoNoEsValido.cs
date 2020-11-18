using System;
using System.Runtime.Serialization;

[Serializable]
internal class FormatoDeDatoIngresadoNoEsValido : Exception
{
    public FormatoDeDatoIngresadoNoEsValido()
    {
    }

    public FormatoDeDatoIngresadoNoEsValido(string message) : base(message)
    {
    }

    public FormatoDeDatoIngresadoNoEsValido(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected FormatoDeDatoIngresadoNoEsValido(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}