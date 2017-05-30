﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAssembly.Instructions
{
	/// <summary>
	/// Tests the <see cref="Int32GreaterThanSigned"/> instruction.
	/// </summary>
	[TestClass]
	public class Int32GreaterThanSignedTests
	{
		/// <summary>
		/// Tests compilation and execution of the <see cref="Int32GreaterThanSigned"/> instruction.
		/// </summary>
		[TestMethod]
		public void Int32GreaterThanSigned_Compiled()
		{
			const int comparand = 0xF;

			var exports = AssemblyBuilder.CreateInstance<CompilerTestBase>(nameof(CompilerTestBase.Test),
				ValueType.Int32,
				 new[]
				 {
					 ValueType.Int32
				 },
				new GetLocal(0),
				new Int32Constant(comparand),
				new Int32GreaterThanSigned(),
				new End());

			foreach (var value in new[] { 0x00, 0x0F, 0xF0, 0xFF, })
				Assert.AreEqual(value > comparand, exports.Test(value) == 1);
		}
	}
}