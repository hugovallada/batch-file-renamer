# batch-file-renamer

## Ferramenta para renomeação em lote de arquivos em um mesmo diretório, ou de um arquivo único

## Como funciona:


    Opção: Indicar se é irá trabalhar em lote/diretório (dir) ou com arquivo(file)

    DIR:

    Caminho: Indicar o caminho do diretório

    Nome Base: Indicar qual o nome base para os seus arquivos, caso fique em branco, utilizará apenas o contador de arquivos como nome
    O formato do nome será XXXX-nomeBase.ext ou XXXX.ext

    Extensões: Indicar as extensões dos arquivos que devem ser renomeados, caso nenhuma seja passada, todas as extensões no diretório serão usadas para renomeação

    Continuar: Após a listagem de todas as extensões que serão renomeadas, o usuário pode cancelar ou continuar a renomeação em lote

    FILE:

    Caminho: Indicar o caminho do arquivo

    Nome: Indicar o novo nome que o arquivo terá
