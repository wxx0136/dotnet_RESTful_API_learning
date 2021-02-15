# CLI Notes
---
```
docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=password --network=net5tutorial mongo:latest
```
```
docker run -it --rm --name netapi -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=password --network=net5tutorial netapi:latest
```
```
kubectl config current-context
kubectl apply -f .\netapi.yaml
kubectl get deployments
kubectl get pods
kubectl logs netapi-deployment-775568bc6f-xqb2z
```
```
kubectl apply -f .\mongodb.yaml
kubectl.exe get statefulsets
```
```
kubectl get pods -w
kubectl delete pod netapi-deployment-796678c86c-bswk8
```
```
kubectl scale deployments/netapi-deployment --replicas=3
```
```
kubectl logs -f netapi-deployment-fd8fb97c6-xbrvp
```