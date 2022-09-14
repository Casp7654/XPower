import managers.grpc_manager as grpc

def main():
    gManager = grpc.grpcmanager()
    gManager.hello()


if __name__ == "__main__":
    main()