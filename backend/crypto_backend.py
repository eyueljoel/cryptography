import sys
import os
import hashlib
import hmac
import struct

# ── AES-256-CBC implemented using only Python built-ins ──────────────────────
# We use Python's built-in hashlib + secrets + manual AES via os.urandom
# Actually we use the built-in 'Cipher' from Python 3.11+ hmm...
# Safest: use Python built-in 'cryptography' alternative = hashlib + XOR stream

def derive_key(password: str, salt: bytes) -> bytes:
    """Derive a 32-byte key from password using PBKDF2 (built into hashlib)."""
    key = hashlib.pbkdf2_hmac(
        hash_name='sha256',
        password=password.encode('utf-8'),
        salt=salt,
        iterations=100000,
        dklen=32
    )
    return key

def xor_bytes(data: bytes, key: bytes) -> bytes:
    """XOR data with repeating key — used as stream cipher."""
    key_len = len(key)
    return bytes(data[i] ^ key[i % key_len] for i in range(len(data)))

def make_keystream(key: bytes, iv: bytes, length: int) -> bytes:
    """Generate a keystream using SHA-256 in counter mode."""
    stream = b""
    counter = 0
    while len(stream) < length:
        block = hashlib.sha256(key + iv + struct.pack('>Q', counter)).digest()
        stream += block
        counter += 1
    return stream[:length]

def encrypt_data(data: bytes, password: str) -> bytes:
    salt = os.urandom(16)
    iv   = os.urandom(16)
    key  = derive_key(password, salt)

    keystream = make_keystream(key, iv, len(data))
    encrypted = xor_bytes(data, keystream)

    # compute HMAC for integrity check
    mac = hmac.new(key, salt + iv + encrypted, hashlib.sha256).digest()

    # format: salt(16) + iv(16) + mac(32) + encrypted data
    return salt + iv + mac + encrypted

def decrypt_data(data: bytes, password: str) -> bytes:
    if len(data) < 64:
        raise ValueError("File is too small or corrupted.")

    salt      = data[0:16]
    iv        = data[16:32]
    mac       = data[32:64]
    encrypted = data[64:]

    key = derive_key(password, salt)

    # verify HMAC first
    expected_mac = hmac.new(key, salt + iv + encrypted, hashlib.sha256).digest()
    if not hmac.compare_digest(mac, expected_mac):
        raise ValueError("Wrong password or corrupted file.")

    keystream = make_keystream(key, iv, len(encrypted))
    return xor_bytes(encrypted, keystream)

# ── File operations ───────────────────────────────────────────────────────────

def encrypt_file(input_path: str, password: str):
    try:
        if not os.path.exists(input_path):
            print("ERROR:File not found: " + input_path)
            return

        with open(input_path, 'rb') as f:
            data = f.read()

        encrypted = encrypt_data(data, password)
        output_path = input_path + '.enc'

        with open(output_path, 'wb') as f:
            f.write(encrypted)

        print("SUCCESS:" + output_path)

    except PermissionError:
        print("ERROR:Permission denied. Try running as administrator.")
    except Exception as ex:
        print("ERROR:" + str(ex))

def decrypt_file(input_path: str, password: str):
    try:
        if not os.path.exists(input_path):
            print("ERROR:File not found: " + input_path)
            return

        with open(input_path, 'rb') as f:
            data = f.read()

        decrypted = decrypt_data(data, password)

        if input_path.endswith('.enc'):
            base = input_path[:-4]
            name, ext = os.path.splitext(base)
            output_path = name + "_decrypted" + ext
        else:
            output_path = input_path + "_decrypted"

        with open(output_path, 'wb') as f:
            f.write(decrypted)

        print("SUCCESS:" + output_path)

    except ValueError as ex:
        print("ERROR:" + str(ex))
    except PermissionError:
        print("ERROR:Permission denied. Try running as administrator.")
    except Exception as ex:
        print("ERROR:" + str(ex))

# ── Entry point ───────────────────────────────────────────────────────────────

if __name__ == "__main__":
    if len(sys.argv) < 4:
        print("ERROR:Usage: crypto_backend.py <encrypt|decrypt> <filepath> <password>")
        sys.exit(1)

    action   = sys.argv[1]
    filepath = sys.argv[2]
    password = sys.argv[3]

    if action == "encrypt":
        encrypt_file(filepath, password)
    elif action == "decrypt":
        decrypt_file(filepath, password)
    else:
        print("ERROR:Unknown action. Use encrypt or decrypt.")