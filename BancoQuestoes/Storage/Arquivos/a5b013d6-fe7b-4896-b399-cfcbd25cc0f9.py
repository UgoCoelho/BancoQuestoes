#busca sequencial
def buscaSequencial(vetor,valor):
    n=len(vetor)
    for i in range(0,n):
        if vetor[i] == valor:
            return i #retornando índice
    return -1

# a= [1,6,5,4,2,9]
# print(buscaSequencial(a,4))
#big O(n)

#busca binária
def buscaBinária(vetor,valor):
    n=len(vetor)
    li=0
    ls=n-1
    while li<=ls:
        media=(li+ls)//2
        if valor == vetor[media]:
            return media
        elif valor < vetor[media]:
            ls=media-1
        else:
            li=media+1
    return -1

# a= [1,2,3,4,5,6] #tem que estar ordenado
# print(buscaBinária(a,4))
#big O(lg n)

#bubble sort
def bubbleSort(x):
    n = len(x)
    for i in range(0,n-1):
        for j in range(n-1,i,-1):
            if x[j-1]>x[j]:
                x[j-1],x[j] = x[j],x[j-1]
    return x

# a= [1,6,5,4,2,9]
# print(bubbleSort(a))
#big O(n2)

#o bubble sort vai fazendo dupla por dupla e nao compara um elemento com todos em uma iteração, e sim dupla por dupla

#selection sort
def selectionSort(x):
    n = len(x)
    for i in range(0,n-1):
        for j in range(i+1,n):
            if x[i]>x[j]:
                x[i],x[j]=x[j],x[i]
    return x
# a= [1,6,5,4,2,9]
# print(selectionSort(a))
#big O(n2)

#o selection sort pega um elemento e vai comparando até encontrar um menor que ele, e colocá-lo na posição certa

#insertion sort
def insertionSort(x):
    n=len(x)
    for i in range(1,n):
        atual = x[i]
        j = i
        while j > 0 and x[j-1] >  atual:
            x[j]=x[j-1]
            j = j-1
        x[j] = atual
    return x
# a= [1,6,5,4,2,9]
# print(insertionSort(a))
#o insertion sort coemça com o 'atual' e esse vai comparando com todos ate achar seu lugar, quando acha, passa para o próximo valor, que vira o novo 'atual'
#big O(n2)

#shell sort
def shellSort(x):
    h = 1
    n = len(x)
    while h < n:
        h = h * 3 + 1
    while h > 1:
        h = h//3
        for i in range(h,n):
            atual = x[i]
            j = i-h
            while j >=0 and atual < x[j]:
                x[j+h] = x[j]
                j = j - h
            x[j+h] = atual
    return x 

# a = [5,1,4,18,3,15,21,6,8,7,2,0,12]
# print(shellSort(a))
#o shell vai trocando o valores distantes dele até chegar em 1, virando o insertion

#merge sort
def mergeSort(x):
    merge(x, 0, len(x))
    return x
def merge(x, ini, fim):
    if fim - ini > 1:
        meio = (ini+fim)//2
        merge(x,ini,meio)
        merge(x,meio,fim)
        concatena(x,ini,meio,fim)

def concatena(x,ini,meio,fim):
    va=x[ini:meio]
    vb=x[meio:fim]
    ia=0
    ib=0
    for i in range(ini,fim):
        if ia == len(va):
            x[i] = vb[ib]
            ib +=1
            continue
        if ib == len(vb):
            x[i] = va[ia]
            ia+=1
            continue
        if va[ia] < vb[ib]:
            x[i] = va[ia]
            ia+=1
            continue
        else:
            x[i] = vb[ib]
            ib+=1
        
# a = [5,1,4,18,3,15,21,6,8,7,2,0,12]
# print(mergeSort(a))
#o merge vai dividindo o vetor em 2 ate ter todos elementos com 1, e vai juntando eles de novo ordenados

def geraHeap(vet,i,n):
    indMaior = i
    indFE = i * 2 + 1
    indFD = i * 2 + 2
    
    if indFE < n and vet[indFE] > vet[indMaior]:
        indMaior = indFE
    if indFD < n and vet[indFD] > vet[indMaior]:
        indMaior = indFD
    if indMaior != i:
        vet[i], vet[indMaior] = vet[indMaior], vet[i]
        geraHeap(vet, indMaior, n)

def heapSort(x):
    n = len(x)
    for i in range(n//2 -1, -1, -1):
        geraHeap(x, i, n)
        x[i], x[0] = x[0], x[i]
        geraHeap(x, 0, i)
    return x

# a = [5,1,4,18,3,15,21,6,8,7,2,0,12]
# print(heapSort(a))
#o heap cria uma arvore binaria com o maior valor ao topo, esse valor vai entrando no final do vetor ate ter todos organizados
