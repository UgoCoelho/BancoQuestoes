# Crie um vetor com 1000 posições ordenado. Faça um contador para determinar quantas vezes o laço de repetição mais interno (onde são feitas as trocas de valores) são executados nos quatro algoritmos.
# Crie um vetor com 1000 posições ordenado de forma decrescente. Faça um contador para determinar quantas vezes o laço de repetição mais interno (onde são feitas as trocas de valores) são executados nos quatro algoritmos.
# Descreva as conclusões sobre suas observações dos números.

ordenado = []
desordenado = []
for i in range(0,1000):
    ordenado.append(i)
for i in range(1000,0,-1):
    desordenado.append(i)    

#shell sort
def shellSort(arr):
    x=arr[:]
    h=1
    n=len(x)
    contador = 0
    while h<n:
        h=h*3+1
    while h>1:
        h//=3
        for i in range(h,n):
            atual = x[i]
            j = i-h
            while j >= 0 and atual < x[j]:
                x[j+h] = x[j]
                j=j-h
                contador += 1
            x[j+h]=atual
    return contador

# print("Shell Sort (Ordenado):", shellSort(ordenado))
# print("Shell Sort (Desordenado):", shellSort(desordenado))
     
#selection sort
def selectionSort(arr):
    x=arr[:]
    n=len(x)
    contador = 0
    for i in range (0,n-1):
        for j in range (i+1,n):
            contador +=1
            if x[i]>x[j]:
                x[i],x[j]=x[j],x[i]
    return contador

# print('Selection Sort (ordenado):', selectionSort(ordenado))
# print('Selection Sort (desordenado):', selectionSort(desordenado))

#bubble sort
def bubbleSort(arr):
    x=arr[:]
    n=len(x)
    contador = 0
    for i in range(0, n-1):
        for j in range(n-1, i, -1): 
            contador += 1
            if x[j-1]>x[j]:
                x[j], x[j-1] = x[j-1], x[j]

    return contador

# print('Bubble Sort (ordenado):', bubbleSort(ordenado))
# print('Bubble Sort (desordenado):', bubbleSort(desordenado))

# #insertion sort
def insertionSort(x):
    n = len(x)
    contador = 0
    for i in range(1,n):
        e=x[i]
        j=i
        while j > 0 and x[j-1]>e:
            x[j]=x[j-1]
            j=j-1
            contador += 1
        x[j]=e
    return contador

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
    contador = 0
    for i in range(ini,fim):
        if ia == len(va):
            x[i] = vb[ib]
            ib +=1
            contador += 1
            continue
        if ib == len(vb):
            x[i] = va[ia]
            ia+=1
            contador += 1
            continue
        if va[ia] < vb[ib]:
            x[i] = va[ia]
            ia+=1
            contador += 1
            continue
        else:
            x[i] = vb[ib]
            ib+=1
            contador += 1
    return contador

a=[i for i in range(0,5000)]
print(mergeSort(a))


# print('Insertion Sort (ordenado):', insertionSort(ordenado))
# print('Insertion Sort (desordenado):', insertionSort(desordenado))

# print('|  Algoritmo  |  Ordenado  |  Desordenado')
# print('------------------------------------------')
# print(f'|    Shell    |     {shellSort(ordenado)}      |     {shellSort(desordenado)}')
# print(f'|  Selection  |     {selectionSort(ordenado)}      |     {selectionSort(desordenado)}') 
# print(f'|   Bubble    |     {bubbleSort(ordenado)}      |     {bubbleSort(desordenado)}')
# print(f'|  Insertion  |     {insertionSort(ordenado)}      |     {insertionSort(desordenado)}') 

