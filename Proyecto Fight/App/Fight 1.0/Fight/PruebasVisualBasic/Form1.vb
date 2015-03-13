Public Class Form1

    Private Sub btnObtenerUnidadDisco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerUnidadDisco.Click
        MessageBox.Show(IO.Path.GetDirectoryName(Reflection.Assembly.GetCallingAssembly.Location))
    End Sub


    '<summary>
    ' Devuelve el path de la aplicación.
    ' Al usarse desde una librería (DLL), hay que usar GetCallingAssembly
    ' para que devuelva el path del ejecutable (o librería) que llama a esta función.
    ' Si no se usa GetCallingAssembly, devolvería el path de la librería.
    '</summary>
    '<param name="backSlash">Opcional. True si debe devolver el path terminado en \</param>
    '<returns>
    ' El path de la aplicación con o sin backslash, según el valor del parámetro.
    '</returns>
    Public Function AppPath( _
            Optional ByVal backSlash As Boolean = False _
            ) As String
        Dim s As String = IO.Path.GetDirectoryName( _
                Reflection.Assembly.GetCallingAssembly.Location)
        ' si hay que añadirle el backslash
        If backSlash Then
            s &= "\"
        End If
        Return s
    End Function

End Class
