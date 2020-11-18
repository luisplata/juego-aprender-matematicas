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
    }
}
