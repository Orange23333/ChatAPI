# ChatAPI

API S/C for chating with AIs.

# ChatAPI.CLI

## Modules

### GPT-6B-J

Files:
```
ChatAPI.CLI/modules/gpt-j-6b/chatapi-gpt-j-6b.py
ChatAPI.CLI/Server/GPTJWrapper.cs #WIP
```

#### chatapi-gpt-j-6b.py

##### Requirement

```bash
python -m pip install torch transformers
```
##### Quick Start

And running with:
```bash
python3 chatapi-gpt-j-6b.py
```

When you see:
```bash
[Info <time>]: Loaded.
[Info <time>]: Running...
```
That represents the prepare work has been done.

Now, you can send a request by save a file into the `requests` folder (will be craete at python work dictory):
```bash
echo 'I like oranges. How about you?' > requests/1.request #Filename must ends with ".request".
```
After the program finished work, the request file will be delete and a new file with extname ".back" which including the result of your request will be create:
```bash
cat requests/1.back
```

##### Exit Program

You can send `Ctrl+C` key as normal.

Or you can create a file named `quit.flag` into `flags` folder:
```bash
touch flags/quit.flag
```
If the program detects the flag file (**the detect work is after generate text**), the program will quit.

##### Get Status Info

Or you can create a file named `status.flag` into `flags` folder:
```bash
touch flags/status.flag
```
And you will get the status info:
```bash
cat flags/status.back
```

**In fact, the `Status` value will always be `running` (** because the detect work is after generate text**).**

# Reference

```
@misc{gpt-j,
  author = {Wang, Ben and Komatsuzaki, Aran},
  title = {{GPT-J-6B: A 6 Billion Parameter Autoregressive Language Model}},
  howpublished = {\url{https://github.com/kingoflolz/mesh-transformer-jax}},
  year = 2021,
  month = May
}
```