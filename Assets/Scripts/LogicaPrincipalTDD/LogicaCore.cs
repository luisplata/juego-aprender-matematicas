using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Tests
{
    public class LogicaCore
    {
        // A Test behaves as an ordinary method
        [TestCase(1, 9, 9)]
        [TestCase(9, 7, 9)]
        [TestCase(1, 1, 1)]
        [TestCase(2, 6, 3)]
        [TestCase(8, 6, 12)]
        public void LogicaDeRespuesta(int tabla, int numero, int esperado)
        {
            //Act
            IControladorRespuestasMono substitutoMono = Substitute.For<IControladorRespuestasMono>();
            LogicaDeRespuestas logica = new LogicaDeRespuestas(substitutoMono);
            //assrt
            Assert.AreEqual(esperado, logica.CalcularResultadoDeLaOpeacionPrincipalDeLaLudica(tabla, numero));
        }

        [TestCase(3, 2, 1)]
        [TestCase(3, 3, 6)]
        public void NumeroDelDado(int respuestaObligatoria, int numeroAnterior, int cantidadDeVecesEjecutado)
        {
            ServiceLocator.Instance.ClearAll();
            ICalculosGenerales subCalculos = Substitute.For<ICalculosGenerales>();
            subCalculos.CalcularintRandom(Arg.Any<int>(), Arg.Any<int>())
                .Returns(respuestaObligatoria);

            ServiceLocator.Instance.RegisterService(subCalculos);
            IManejoDeDatosDelJuego subManejador = Substitute.For<IManejoDeDatosDelJuego>();
            ServiceLocator.Instance.RegisterService(subManejador);

            IDadoMono subDadoMono = Substitute.For<IDadoMono>();
            LogicaDeDado logica = new LogicaDeDado(subDadoMono);

            logica.NumeroAnterior = numeroAnterior;

            logica.CalcularElNumeroDelDado();

            subCalculos.Received(cantidadDeVecesEjecutado)
                .CalcularintRandom(Arg.Any<int>(), Arg.Any<int>());
        }

        [TestCase(3, 2, 1)]
        [TestCase(3, 3, 6)]
        public void NumeroDeRuleta(int respuestaObligatoria, int numeroAnterior, int cantidadDeVecesEjecutado)
        {
            ServiceLocator.Instance.ClearAll();
            ICalculosGenerales subCalculos = Substitute.For<ICalculosGenerales>();
            subCalculos.CalcularintRandom(Arg.Any<int>(), Arg.Any<int>())
                .Returns(respuestaObligatoria);

            ServiceLocator.Instance.RegisterService(subCalculos);
            IManejoDeDatosDelJuego subManejador = Substitute.For<IManejoDeDatosDelJuego>();
            ServiceLocator.Instance.RegisterService(subManejador);

            IRuletaMono subRuletaMono = Substitute.For<IRuletaMono>();
            LogicaDeRuleta logica = new LogicaDeRuleta(subRuletaMono);

            logica.NumeroAnterior = numeroAnterior;

            logica.CalcularNumeroDeRuleta();

            subCalculos.Received(cantidadDeVecesEjecutado)
                .CalcularintRandom(Arg.Any<int>(), Arg.Any<int>());
        }
    }
}
