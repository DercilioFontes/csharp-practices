#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch16Ex02
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 1 "default.cshtml"
using System.Web.WebPages;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class @default : defaultBase
{

#line hidden

public override void Execute()
{
WriteLiteral("\n");


#line 3 "default.cshtml"
  
    Player[] players = new Player[2];
    var player1 = HelperPage.Request.Form["PlayerName1"];
    var player2 = HelperPage.Request.Form["PlayerName2"];
    if(HelperPage.IsPost)
    {
        players[0] = new Player(player1);
        players[1] = new Player(player2);
        Game newGame = new Game();
        newGame.SetPlayers(players);
        newGame.DealHands();
    }



#line default
#line hidden
WriteLiteral("\n\n<!DOCTYPE html>\n<html");

WriteLiteral(" en=\"en\"");

WriteLiteral(">\n    <head>\n        <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(@" />
        <style>
            body {
                font-family: Verdana, Geneva, Tahoma, sans-serif;
                margin-left: 50px;
                margin-top: 50px;
            }
            div{
                border: 1px solid black;
                width: 40%;
                margin: 1.2em;
                padding: 1em;
            }
        </style>
        <title>BensCards: a new exciting card game. By dafdev.</title>
    </head>
    <body>
");


#line 38 "default.cshtml"
        

#line default
#line hidden

#line 38 "default.cshtml"
         if(HelperPage.IsPost){


#line default
#line hidden
WriteLiteral("            <label");

WriteLiteral(" id=\"labelGoal\"");

WriteLiteral(">Which player has the best hand.</label>\n");

WriteLiteral("            <br />\n");

WriteLiteral("            <div>\n                <p><label");

WriteLiteral(" id=\"labelPlayer1\"");

WriteLiteral(">Player1: ");


#line 42 "default.cshtml"
                                                Write(player1);


#line default
#line hidden
WriteLiteral("</label></p>\n");


#line 43 "default.cshtml"
                

#line default
#line hidden

#line 43 "default.cshtml"
                 foreach(Card card in players[0].PlayHand)
                {


#line default
#line hidden
WriteLiteral("                    <img");

WriteLiteral(" width=\"75px\"");

WriteLiteral(" height=\"100px\"");

WriteLiteral(" alt=\"cardImage\"");

WriteAttribute ("src", " src=\"", "\""
, Tuple.Create<string,object,bool> ("", "https://dafdevcards.blob.core.windows.net/carddeck/", true)

#line 45 "default.cshtml"
                                                                                      , Tuple.Create<string,object,bool> ("", card.imageLink

#line default
#line hidden
, false)
);
WriteLiteral("/>\n");


#line 46 "default.cshtml"
                }


#line default
#line hidden
WriteLiteral("            </div>\n");

WriteLiteral("            <div>\r\n                <p><label");

WriteLiteral(" id=\"labelPlayer2\"");

WriteLiteral(">Player2: ");


#line 49 "default.cshtml"
                                                Write(player2);


#line default
#line hidden
WriteLiteral("</label></p>\r\n");


#line 50 "default.cshtml"
                

#line default
#line hidden

#line 50 "default.cshtml"
                 foreach (Card card in players[1].PlayHand)
                {


#line default
#line hidden
WriteLiteral("                    <img");

WriteLiteral(" width=\"75px\"");

WriteLiteral(" height=\"100px\"");

WriteLiteral(" alt=\"cardImage\"");

WriteAttribute ("src", " src=\"", "\""
, Tuple.Create<string,object,bool> ("", "https://dafdevcards.blob.core.windows.net/carddeck/", true)

#line 52 "default.cshtml"
                                                                                      , Tuple.Create<string,object,bool> ("", card.imageLink

#line default
#line hidden
, false)
);
WriteLiteral(" />\r\n");


#line 53 "default.cshtml"
                }


#line default
#line hidden
WriteLiteral("            </div>\n");


#line 55 "default.cshtml"
        }
        else {


#line default
#line hidden
WriteLiteral("            <label");

WriteLiteral(" id=\"labelGoal\"");

WriteLiteral(">Enter the players name and deal the cards.</label>\n");

WriteLiteral("            <br />");

WriteLiteral("<br />\n");

WriteLiteral("            <form");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\n                <div>\r\n                    <p>Player 1: ");


#line 61 "default.cshtml"
                            Write(HelperPage.Html.TextBox("PlayerName1"));


#line default
#line hidden
WriteLiteral("</p>\r\n                    <p>Player 2: ");


#line 62 "default.cshtml"
                            Write(HelperPage.Html.TextBox("PlayerName2"));


#line default
#line hidden
WriteLiteral("</p>\n                    <p><input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Deal Cards\"");

WriteLiteral(" class=\"submit\"");

WriteLiteral("/></p>\r\n                </div>\n            </form>\n");


#line 66 "default.cshtml"
        }


#line default
#line hidden
WriteLiteral("    </body>\n</html>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class defaultBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the 
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591
