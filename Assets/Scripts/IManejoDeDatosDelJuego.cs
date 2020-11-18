public interface IManejoDeDatosDelJuego
{
    void GuardarTablaDeMultiplicar(int tabla);
    void GuardarNumeroDeLaOperacion(int numero);
    int ObtenerTablaDeMultiplicar();
    int ObtnerNumeroParaLaOperacion();
}