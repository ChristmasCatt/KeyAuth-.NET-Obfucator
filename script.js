function convertJStoCSharp() {
    var jsCode = document.getElementById("jsCode").value;

var csCode = jsCode.replace(/var /g, "var ");

csCode = csCode.replace(/console.log/g, "Console.WriteLine");

csCode = csCode.replace(/function /g, "static void ");

csCode = csCode.replace(/'/g, '"');

csCode = csCode.replace(/{/g, "{");
csCode = csCode.replace(/}/g, "}");

csCode = csCode.replace(/==/g, "==");

csCode = csCode.replace(/!=/g, "!=");

csCode = csCode.replace(/for \(var /g, "for (int ");
csCode = csCode.replace(/ in /g, " = 0; ");
csCode = csCode.replace(/\)\s*{/g, "; ");

csCode = csCode.replace(/if \(/g, "if (");
csCode = csCode.replace(/\)\s*{/g, ") {");

csCode = csCode.replace(/undefined/g, "null");

csCode = csCode.replace(/this/g, "this");

csCode = csCode.replace(/new Array/g, "new List");

csCode = csCode.replace(/\b(\d+)\b/g, "int $1");

csCode = csCode.replace(/\b(true)\b/g, "bool $1");
csCode = csCode.replace(/\b(false)\b/g, "bool $1");

csCode = csCode.replace(/typeof /g, "typeof ");

csCode = csCode.replace(/instanceof /g, "is ");

csCode = csCode.replace(/Math.abs/g, "Math.Abs");
csCode = csCode.replace(/Math.ceil/g, "Math.Ceiling");
csCode = csCode.replace(/Math.floor/g, "Math.Floor");
csCode = csCode.replace(/Math.round/g, "Math.Round");

csCode = csCode.replace(/\+\s*'/g, " + \"");
csCode = csCode.replace(/'\s*\+/g, "\" + ");

document.getElementById("csCode").value = csCode;
}