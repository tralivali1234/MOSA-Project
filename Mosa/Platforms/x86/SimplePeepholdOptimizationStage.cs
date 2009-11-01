/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (grover) <sharpos@michaelruck.de>
 *  Scott Balmos <sbalmos@fastmail.fm>
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using System;
using System.Diagnostics;
using System.IO;

using Mosa.Runtime.CompilerFramework;
using Mosa.Runtime.Linker;
using Mosa.Runtime.Metadata;
using Mosa.Runtime.Metadata.Signatures;

using IR = Mosa.Runtime.CompilerFramework.IR;
using CIL = Mosa.Runtime.CompilerFramework.CIL;

namespace Mosa.Platforms.x86
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class SimplePeepholdOptimizationStage :
		BaseTransformationStage,
		IMethodCompilerStage,
		IPlatformTransformationStage
	{

		#region IMethodCompilerStage Members

		/// <summary>
		/// Retrieves the name of the compilation stage.
		/// </summary>
		/// <value>The name of the compilation stage.</value>
		public override string Name
		{
			get { return @"X86.SimplePeepholdOptimizationStage"; }
		}

		/// <summary>
		/// Adds this stage to the given pipeline.
		/// </summary>
		/// <param name="pipeline">The pipeline to add this stage to.</param>
		public override void AddToPipeline(CompilerPipeline<IMethodCompilerStage> pipeline)
		{
			pipeline.InsertAfter<TweakTransformationStage>(this);
		}

		#endregion // IMethodCompilerStage Members

		/// <summary>
		/// Performs stage specific processing on the compiler context.
		/// </summary>
		/// <param name="compiler">The compiler context to perform processing in.</param>
		public override void Run(IMethodCompiler compiler)
		{
			base.Run(compiler);

			foreach (BasicBlock block in BasicBlocks) {
				Context prev = null;
				for (Context ctx = new Context(InstructionSet, block); !ctx.EndOfInstruction; ctx.GotoNext()) {
					if (ctx.Instruction != null)
						if (!ctx.Ignore) {
							if (prev != null) {
								if (ctx.Instruction is CPUx86.MovInstruction && prev.Instruction is CPUx86.MovInstruction)
									if (prev.Result == ctx.Operand1 && prev.Operand1 == ctx.Result) {
										ctx.Remove();
										continue;
									}

								//if (ctx.Instruction is CPUx86.AddInstruction && prev.Instruction is CPUx86.MovInstruction &&
									//&& ctx.Operand1 is RegisterOperand && prev.Operand1 is ConstantOperand)
							}

							prev = ctx.Clone();
						}
				}
			}

		}
	}
}
